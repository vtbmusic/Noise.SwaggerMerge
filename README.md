# Noise.SwaggerMerge
Merge openapi3.0 from different services under the microservice architecture

example
```json
  {
  "SwaggerConfig": {
    //"Host": "localhost:8080",
    "Info": {
      "Title": "VTuberMusic Noise Api",
      "Version": "1.0"
    },
    "Schemes": [
      "http",
      "https"
    ],
    "SecurityDefinitions": {
      "ApiKeyAuth": {
        "Type": "apiKey",
        "In": "header",
        "Name": "Authorization"
      }
    },
    "Security": [
      {
        "ApiKeyAuth": []
      }
    ]
  },
  "ServiceSwaggerEndpoint": [
    {
      "Name": "file Api",
      "File": "http://localhost:5220/file/v1/swagger.json",
      "Path": "/file/v1/swagger.json"
    },
    {
      "Name": "identity Api",
      "File": "http://localhost:5068/identity/v1/swagger.json",
      "Path": "/identity/v1/swagger.json"
    }
  ]
}
```
