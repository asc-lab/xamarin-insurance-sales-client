# ASC LAB Xamarin.Forms - Insurance Sales Mobile Client

This is an example simple mobile client for our [.NET Core Sales Portal](https://github.com/asc-lab/dotnetcore-microservices-poc) made to showcase the idea of [.NET Everywhere](https://visualstudiomagazine.com/articles/2017/03/16/dotnet-everywhere-cross-platform-dev-xamarin.aspx).

- Xamarin.Forms 4.x
- Refit
- HttpTracer
- MvvmHelpers
- FFImageLoading

## Architecture overview

![alt text](./images/logical_arch.png "Layered architecture overview")

Application is design as classic 3 layers app.

- **Views**: This layer contains views implemented in XAML such approach allow us to use Visual Studio features like XAML Hot Reload during implementation
- **View Models**: This layer allow us seperate our logic for view implementation. Additionally we are able to easily test application logic with Unit Tests
- **Services**: This layer is responsible for communication with API. This layer is implemented using Refit library.

## Run

1. Clone repo
2. Restore NuGet packages
3. Deploy to device using Visual Studio
