# Search Service API #

This API implements [content-api.yml](content-api.yml).

## Client ##

Client code has been generated, and can be found in the content-api-client directory.

## Usage ##

### Request ###

Send an HTTP POST to `/search` with a `searchQuery` in the body. 
The searchQuery can be either a single Content ID, or part of a Title.

For example:

```
{
	"searchQuery": "OM984813"
}
```

or

```
{
	"searchQuery": "bananas"
}
```

### Response ###

The response will be an array of `contentResults` similar to the following.
```
{
    "contentResults": [
        {
            "title": "Media and Technical Digest March 2020",
            "contentId": "OM984813",
            "author": "sitecore\irwinj",
            "contentType": "Article"
        }
    ]
}
```

## Primary Developer ##

V1 of this API was created by Thomas Betts <thomas.betts@informa.com>