using InsuranceSales.i18n;
using InsuranceSales.Models.Offer;
using Newtonsoft.Json;
using System;

namespace InsuranceSales.Serialization
{
    public class TypeEnumConverter : JsonConverter
    {
        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();

        public override bool CanConvert(Type t) => t == typeof(QuestionTypeEnum) || t == typeof(QuestionTypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader?.TokenType == JsonToken.Null)
                return null;

            var value = serializer?.Deserialize<string>(reader);
            return value switch
            {
                "choice" => QuestionTypeEnum.Choice,
                "numeric" => QuestionTypeEnum.Numeric,
                _ => throw new Exception(Exceptions.CannotUnmarshalTypeEnum)
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer?.Serialize(writer, null);
                return;
            }
            var value = (QuestionTypeEnum)untypedValue;
            switch (value)
            {
                case QuestionTypeEnum.Choice:
                    serializer?.Serialize(writer, "choice");
                    return;
                case QuestionTypeEnum.Numeric:
                    serializer?.Serialize(writer, "numeric");
                    return;
                default:
                    throw new Exception(Exceptions.CannotUnmarshalTypeEnum);
            }
        }
    }
}
