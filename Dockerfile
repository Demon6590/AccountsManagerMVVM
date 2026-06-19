FROM ://microsoft.com AS build
WORKDIR /src

COPY ["AccountsManagerMVVM/AccountsManagerMVVM.csproj", "AccountsManagerMVVM/"]
RUN dotnet restore "AccountsManagerMVVM/AccountsManagerMVVM.csproj"

COPY . .
WORKDIR "/src/AccountsManagerMVVM"

RUN dotnet publish "AccountsManagerMVVM.csproj" -c Release -o /app/publish /p:RuntimeIdentifier=browser-wasm

FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
