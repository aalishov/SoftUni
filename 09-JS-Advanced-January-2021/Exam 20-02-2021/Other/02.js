class Story {
    #comments;
    #likes;
 
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this.#comments = [];
        this.#likes = [];
    }
 
    get likes() {
        if (this.#likes.length === 0) {
            return `${this.title} has 0 likes`;
        } else if (this.#likes.length === 1) {
            let username = this.#likes[0];
 
            return `${username} likes this story!`;
        } else {
            let username = this.#likes[0];
            let otherUsersCount = this.#likes.length - 1;
 
            return `${username} and ${otherUsersCount} others like this story!`;
        }
    };
 
    like(username) {
        if (this.#likes.some(x => x === username)) {
            throw new Error('You can\'t like the same story twice!');
        }
 
        if (this.creator === username) {
            throw new Error('You can\'t like your own story!');
        }
 
        this.#likes.push(username);
        return `${username} liked ${this.title}!`;
    };
 
    dislike(username) {
        if (!this.#likes.some(x => x === username)) {
            throw new Error('You can\'t dislike this story!');
        }
 
        let usernameIndex = this.#likes.indexOf(username);
        this.#likes.splice(usernameIndex, 1);
 
        return `${username} disliked ${this.title}`;
    };
 
    comment(username, content, id) {
        if (id === undefined ||
            !this.#comments.some(c => c.id === id)) {
 
            id = this.#comments.length + 1;
 
            this.#comments.push({
                id,
                username,
                content,
                replies: []
            });
 
            return `${username} commented on ${this.title}`;
        } else {
            let comment = this.#comments.find(c => c.id === id);
 
            if(comment.replies.length === 0) {
                comment.replies.push({
                    id: `${comment.id}.1`,
                    username,
                    content
                });
            } else {
                let lastReply = comment.replies[comment.replies.length - 1];
                let lastDigitPlusOne = Number(lastReply.id[lastReply.id.length - 1]) + 1;
                let newId = `${comment.id}.${lastDigitPlusOne}`;
 
                comment.replies.push({
                    id: newId,
                    username,
                    content
                });
            }
 
            return 'You replied successfully';
        }
    };
 
    toString(sortingType) {
        let result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this.#likes.length}`);
        result.push(`Comments:`);
 
        let comments = this.#comments.slice();
 
        if (sortingType === 'asc') {
            comments.sort((a, b) => {
                return a.id.toString().toLowerCase().localeCompare(b.id.toString().toLowerCase());
            })
        } else if (sortingType === 'desc') {
            comments.sort((a, b) => {
                return b.id.toString().toLowerCase().localeCompare(a.id.toString().toLowerCase());
            })
        } else if (sortingType === 'username') {
            comments.sort((a, b) => {
                return a.username.toLowerCase().localeCompare(b.username.toLowerCase());
            })
        }
 
        for (const comment of comments) {
            result.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);
 
            if (sortingType === 'asc') {
                comment.replies.sort((a, b) => {
                    return a.id.localeCompare(b.id);
                });
            } else if (sortingType === 'desc') {
                comment.replies.sort((a, b) => {
                    return b.id.localeCompare(a.id);
                });
            } else if (sortingType === 'username') {
                comment.replies.sort((a, b) => {
                    return a.username.localeCompare(b.username);
                });
            }
 
            for (const reply of comment.replies) {
                result.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`);
            }
        }
 
        return result.join('\n');
    };
}