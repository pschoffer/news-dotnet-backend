# News-dotnet-backend

News aggregator service that consumes xml data streams and provide set of Rest endpoints to get the data from.

## APIs

The backend exposes two sets of APIs.

- news sources api on path `/api/newssource`

- news articles on the path `/api/news` and `/api/news/<source_id>`

## Run

To run the server on linux machine you can run following command that will start a server on [localhost:5000](http://localhost:5000)

`dotnet run`

## Links

[frontend](https://github.com/pschoffer/news-angular-frontend)
