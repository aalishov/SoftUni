class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this.comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`;
        }
        else if(this._likes.length>1) {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
        }
    }
    set likes([]){
        this._likes=[];
    }

    like(username) {
        if (this._likes.some(x => x === username)) {
            throw new Error("You can't like the same story twice!");
        }
        if (this.creator === username) {
            throw new Error("You can't like your own story!");
        }
        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.some(x => x === username)) {
            throw new Error("You can't dislike this story!");
        }
        const findIndex = this._likes.findIndex(x => x === username);
        this._likes.splice(findIndex, 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let currentComment = this.comments.find(x => x.id === id)
        if (id === undefined || currentComment == undefined) {
            let comment = {
                id: this.comments.length + 1,
                username: username,
                content: content,
                replies: []
            };
            this.comments.push(comment);
            return `${username} commented on ${this.title}`;
        }
        else {
            let count = currentComment.replies.length
            currentComment.replies.push({
                id: count + 1,
                username: username,
                content: content
            });
            return `You replied successfully`;
        }
    }

    toString(sortingType) {
        if (sortingType === 'username') {
            return [
                `Title: ${this.title}`,
                `Creator: ${this.creator}`,
                `Likes: ${this._likes.length}`,
                `Comments:`,
                this.comments
                    .sort((a, b) => a.username.localeCompare(b.username))
                    .map(c => `-- ${c.id}. ${c.username}: ${c.content}${c.replies.length>0?"\n":""}${c.replies
                        .sort((a, b) => a.username.localeCompare(b.username))
                        .map(r => `--- ${c.id}.${r.id}. ${r.username}: ${r.content}`)
                        .join('\n')}`)
                    .join('\n')
            ]
                .join('\n');
        }
        else if (sortingType === 'asc') {
            return [
                `Title: ${this.title}`,
                `Creator: ${this.creator}`,
                `Likes: ${this._likes.length}`,
                `Comments:`,
                this.comments
                    .sort((a, b) => a.id.toString().localeCompare(b.id.toString()))
                    .map(c => `-- ${c.id}. ${c.username}: ${c.content}${c.replies.length>0?"\n":""}${c.replies
                        .sort((a, b) => a.id.toString().localeCompare(b.id.toString()))
                        .map(r => `--- ${c.id}.${r.id}. ${r.username}: ${r.content}`)
                        .join('\n')}`)
                    .join('\n')
            ]
                .join('\n');
        }
        else if (sortingType === 'desc') {
            return [
                `Title: ${this.title}`,
                `Creator: ${this.creator}`,
                `Likes: ${this._likes.length}`,
                `Comments:`,
                this.comments
                    .sort((a, b) => a.id.toString().localeCompare(b.id.toString()))
                    .reverse()
                    .map(c => `-- ${c.id}. ${c.username}: ${c.content}${c.replies.length>0?"\n":""}${c.replies
                        .sort((a, b) => a.id.toString().localeCompare(b.id.toString()))
                        .reverse()
                        .map(r => `--- ${c.id}.${r.id}. ${r.username}: ${r.content}`)
                        .join('\n')}`)
                    .join('\n')
            ]
                .join('\n');
        }


    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));


