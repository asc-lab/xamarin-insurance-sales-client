﻿using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InsuranceSales.Models
{
    // <auto-generated />
    //
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var product = Product.FromJson(jsonString);
    public partial class Product
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("covers")]
        public Cover[] Covers { get; set; }

        [JsonProperty("questions")]
        public Question[] Questions { get; set; }

        [JsonProperty("maxNumberOfInsured")]
        public long MaxNumberOfInsured { get; set; }
    }

    public class Cover
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("optional")]
        public bool Optional { get; set; }

        [JsonProperty("sumInsured", NullValueHandling = NullValueHandling.Ignore)]
        public long? SumInsured { get; set; }
    }

    public class Question
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("choices", NullValueHandling = NullValueHandling.Ignore)]
        public Choice[] Choices { get; set; }
    }

    public class Choice
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public enum TypeEnum { Choice, Numeric };

    public partial class Product
    {
        public static Product[] FromJson(string json) => JsonConvert.DeserializeObject<Product[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Product[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "choice":
                    return TypeEnum.Choice;
                case "numeric":
                    return TypeEnum.Numeric;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Choice:
                    serializer.Serialize(writer, "choice");
                    return;
                case TypeEnum.Numeric:
                    serializer.Serialize(writer, "numeric");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}