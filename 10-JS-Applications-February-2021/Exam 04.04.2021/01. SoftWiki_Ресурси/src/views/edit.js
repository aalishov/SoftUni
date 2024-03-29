import { html } from '../../node_modules/lit-html/lit-html.js';

import { editItem, getItem } from '../api/data.js';
//import { showNotification } from './notification.js'

const editTemplate = (article, onSubmit) => html`
        <section id="edit-page" class="content">
            <h1>Edit Article</h1>

            <form id="edit" action="#" method="" @submit=${onSubmit}>
                <fieldset>
                    <p class="field title">
                        <label for="title">Title:</label>
                        <input type="text" name="title" id="title" placeholder="Enter article title" .value=${article.title}>
                    </p>

                    <p class="field category">
                        <label for="category">Category:</label>
                        <input type="text" name="category" id="category" placeholder="Enter article category" .value=${article.category}>
                    </p>
                    <p class="field">
                        <label for="content">Content:</label>
                        <textarea name="content" id="content" .value=${article.content}></textarea>
                    </p>

                    <p class="field submit">
                        <input class="btn submit" type="submit" value="Save Changes">
                    </p>

                </fieldset>
            </form>
        </section>
`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const article = await getItem(id);
    ctx.render(editTemplate(article, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);

        const title = formData.get('title').trim();
        const category = formData.get('category').trim();
        const content = formData.get('content').trim();

        if (!title || !category || !content) {
            //return showNotification('All fields are required!');
            return alert('All fields are required!');
        }
        if (!(category=='JavaScript'||category=='C#'||category=='Java'||category=='Python')) {
            return alert('The category must be one of "JavaScript", "C#", "Java", or "Python"');
        }

        const item = {
            title,
            category,
            content
        }
        await editItem(id, item);
        ctx.setUserNav();
        ctx.page.redirect('/details/'+id);
    }
}