# News Dotnet Backend

News aggregator service that consumes xml data streams and provide set of Rest endpoints to get the data from.

## APIs

The backend exposes two sets of APIs.

- news sources api on path `/api/newssource`

- news articles on the path `/api/news` and `/api/news/<source_id>`

## Enhancements

This is a sceleton application just to show some basic approaches. Following is a list of enhancements that could be done to it:

- Make fetching news in a scheduled batch manner instead of only on startup (this require to deal with incremental updates, therefore dolving the ID issue as well)

- News Id would need some rething as this approach would fail in multiinstance environment + would not work for updating the news (maybe hash of a title could be used instead)

- Persist data in real DB

- Provide APIs to register new news sources

- Testing!

## Run

To run the server on linux machine you can run following command that will start a server on [localhost:5000](http://localhost:5000)

`dotnet run`

## Links

[frontend](https://github.com/pschoffer/news-angular-frontend)
