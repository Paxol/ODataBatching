# ODataBatching
Explample project to see how to use batching with odata

## Batch request example
Make a POST request to `/odata/$batch` with the body as:
```
{
  "requests": [
    {
      "method": "POST",
      "url": "http://localhost:5000/api/ClockAction",
      "headers": {
        "content-type": "application/json"
      },
      "body": {
        "id": "8fa85f64-5717-4562-b3fc-2c963f66afa6",
        "operator": "Test8",
        "time": "2023-05-11T12:49:37.682Z"
      }
    },
    {
      "method": "POST",
      "url": "http://localhost:5000/api/ClockAction",
      "headers": {
        "content-type": "application/json"
      },
      "body": {
        "id": "7fa85f64-5717-4562-b3fc-2c963f66afa6",
        "operator": "Test7",
        "time": "2023-05-11T12:49:37.682Z"
      }
    }
  ]
}
```

The expected response will be:
```
{
  "responses": [
    {
      "id": "1",
      "status": 200,
      "headers": {
        "content-type": "application/json; charset=utf-8"
      },
      "body": {
        "id": "8fa85f64-5717-4562-b3fc-2c963f66afa6",
        "operator": "Test8",
        "time": "2023-05-11T12:49:37.682+00:00"
      }
    },
    {
      "id": "2",
      "status": 200,
      "headers": {
        "content-type": "application/json; charset=utf-8"
      },
      "body": {
        "id": "7fa85f64-5717-4562-b3fc-2c963f66afa6",
        "operator": "Test7",
        "time": "2023-05-11T12:49:37.682+00:00"
      }
    }
  ]
}
```