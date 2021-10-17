# Brandon_RedditAPI

### Contents
##### Posts
* [GET : "api/posts/"](https://github.com/BCalitz/Brandon_RedditAPI/blob/master/README.md#get--apiposts)

### Authenticatiom

you can get an APi key by logging in/ registering and calling the getkey route
put your apiKey in the Header with the Header name of **"ApiKey"**

## Objects

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
	



## Posts
* ##### GET : "api/posts/"
		
	Gets all posts.
	
	Result :
	```	
	<Post>[]
	```
		
		
	
* ##### GET : "api/posts/{PostId}"
		
	Gets a post.
	
	Result :
	```	
	<Post>
	```
		
		

* ##### POST : "api/posts/"

	Creates a post.

	**Requires ApiKey**

	body :
	
	Field		     | Info
	------------ | -------------
	title(string) | The title of the post.
	content(string) | The content of the post.
	tags(string) | tags seperated by commas eg. "1,2"
```
{
"title":<title>,
"content": <content>,
"tags": <tags>
}
```
	
	
* ##### PUT : "api/posts/{PostId}" 

	Edits a post.

	**Requires ApiKey**
	
	**Api key has to belong to owner of Post**

	body :
	
	Field		     | Info
	------------ | -------------
	title | The title of the post.
	content | The content of the post.
	tags | tags seperated by commas eg. "1,2"
	
```
{
"title":<title>,
"content": <content>,
"tags": <tags>
}
```
	
	
* ##### DELETE : "api/posts/{PostId}" 
	
	Deletes a post.

	**Requires ApiKey**

	**Api key has to belong to owner of Post**
	
	
## Comments
* ##### GET : "api/comments/"
		
	Gets all Comment from a post.
	
	body :
	
	Field		     | Info
	------------ | -------------
	postId(string) | Id of a post
	
	```	
	<postId>
	```
	
	Result :
	```	
	<Comment>[]
	```
	
	
		
		
	
* ##### POST : "api/comments/"
		
	Creates a comment.
	
	**Requires ApiKey**
	
	body :
	
	Field		     | Info
	------------ | -------------
	postId(string) | Id of a post
	content(string) | The comment content.
	
	```	
	{
	"postid":<postId>,
	"content":<content>
	}
	```
	
* ##### PUT : "api/comments/{commentId}"
		
	Edits a comment.
	
	**Requires ApiKey**
	
	**Api key has to belong to owner of Comment**
	
	body :
	
	Field		     | Info
	------------ | -------------
	content(string) | The comment content.
	
	```	
	{
	"content":<content>
	}
	```

## Users

* ##### GET : "api/users/getkey"
		
	Gets a Users ApiKey.
	
	**Requires User Credentials**
	
	
	body :
	
	Field		     | Info
	------------ | -------------
	Username(sting) | Username of user.
	Password(string) | Password of user.
	
	```	
	{
	"username":<username>,
	"password":<password>
	}
	```
	
	Result :
	```	
	<ApiKey>
	```
	
* ##### GET : "api/users/userposts"
		
	Gets posts made by a user.
	
	
	body :
	
	Field		     | Info
	------------ | -------------
	Username(sting) | Username of user.
	
	```	
	<username>
	```
	
	Result :
	```	
	<Post>[]
	```
	
* ##### GET : "api/users/myposts"
		
	Gets posts made by you.
	
	**Requires ApiKey**
	
	
	Result :
	```	
	<Post>[]
	```
	
* ##### GET : "api/users/myactivity"
		
	Gets all posts you have voted on.
	
	**Requires ApiKey**
	
	
	Result :
	```	
	<Post>[]
	```
	
* ##### GET : "api/users/getUser"
		
	Gets Users info from their Id
	
	
	Result :
	```	
	{
	"Id":<UserID>
	"username":<Username>
	}
	```
	
* ##### POST : "api/users/register"
		
	registers a User.
	
	
	body :
	
	Field		     | Info
	------------ | -------------
	Username(sting) | Username of user.
	Password(string) | Password of user.
	
	```	
	{
	"username":<Username>,
	"Password":<Password>
	}
	```
	
## Other

* ##### POST : "api/posts/vote"
		
	make a vote.
	
	
	body :
	
	Field		     | Info
	------------ | -------------
	thingId(sting) | Id of thing(post or comment).
	rating(int) | Rating of vote : -1 for downvote, 1 for upvote.
	
	```	
	{
	"thingID":<thingId>,
	"rating":<rating>
	}
	```
