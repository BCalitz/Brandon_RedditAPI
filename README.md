# Brandon_RedditAPI

### Contents
##### Posts
* [GET : "api/posts/"](https://github.com/BCalitz/Brandon_RedditAPI/blob/master/README.md#L52)

### Authenticatiom

you can get an APi key by logging in/ registering and calling the getkey route
put your apiKey in the Header with the Header name of **"ApiKey"**

### Objects

#### Post

```
{
	"id": "<string>",
	"userId": "<string>",
	"votes": {
		"upVotes": <int>,
		"downVotes": "<int>"
	},
	"postDate": "<date>",
	"comments": null,
	"title": "<string>",
	"tags": "<string>",
	"content": "<string>"
}
```
	
#### Comment
	
```
{
	"id": <string>,
	"userId": <string>,
	"votes": {
		"upVotes": <int>,
		"downVotes": <int>
	},
	"postDate":<date>,
	"postId": <string>,
	"content": <string>
}
```
	



### Posts
* ##### GET : "api/posts/"
		
	Gets all posts.
	
	Result :
	```	
	<Post>
	```
		
		
	
* ##### GET : "api/posts/{PostId}"
		
	Gets all posts.
	
	Result :
	```	
	<Post>
	```
		
		

* ##### POST : "api/posts/" 

	**Requires ApiKey**

	
	Field		     | Info
	------------ | -------------
	title | The title of the post.
	content | The content of the post.
	tags | tags seperated by commas eg. "1,2"
	
	
* ##### PUT : "api/posts/{PostId}" 

	**Requires ApiKey**
	
	**Api key has to belong to owner of Post**

	
	Field		     | Info
	------------ | -------------
	title | The title of the post.
	content | The content of the post.
	tags | tags seperated by commas eg. "1,2"
	
	* ##### DELETE : "api/posts/{PostId}" 

	**Requires ApiKey**
	
	**Api key has to belong to owner of Post**
	
	
	
