# Multi Tenant Demo

To run in terminal: 

```
sudo nano /etc/hosts
```

add the required custom hostnames to hosts file

```
127.0.0.1       ao41n44.infinifty.local
127.0.0.1       0ff4daf.infinifty.local
```

then all run code

```
dotnet run --urls "http://infinifty.local"
```

url is not so important, it should work as long as you are running on port 80