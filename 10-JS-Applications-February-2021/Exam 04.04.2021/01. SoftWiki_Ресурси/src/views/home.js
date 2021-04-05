import { html } from '../../node_modules/lit-html/lit-html.js'
import { getAllCategories } from '../api/data.js'

const allCategoriesTemplate = (data) => html`
<section id="home-page" class="content">
    <section id="home-page" class="content">
        <h1>Recent Articles</h1>
        <section class="recent js">
            <h2>JavaScript</h2>
            ${data.filter(x => x.category == 'JavaScript').length > 0 &&data.filter(x => x.category == 'JavaScript')[0].title != '' ? html`<article>
                <h3>${data.filter(x => x.category == 'JavaScript')[0].title}</h3>
                <p>${data.filter(x => x.category == 'JavaScript')[0].content}</p>
                <a href=${`/details/${data.filter(x => x.category == 'JavaScript')[0]._id}`}
                    class="btn details-btn">Details</a>
            </article>`: html` <h3 class="no-articles">No articles yet</h3>`}

        </section>
        <section class="recent csharp">
            <h2>C#</h2>
            ${data.filter(x => x.category == 'C#').length > 0 && data.filter(x => x.category == 'C#')[0].title != '' ? html`<article>
                <h3>${data.filter(x => x.category == 'C#')[0].title}</h3>
                <p>${data.filter(x => x.category == 'C#')[0].content}</p>
                <a href=${`/details/${data.filter(x => x.category == 'C#')[0]._id}`} class="btn details-btn">Details</a>
            </article>`: html` <h3 class="no-articles">No articles yet</h3>`}
        </section>
        <section class="recent java">
            <h2>Java</h2>
            ${data.filter(x => x.category == 'Java').length > 0 &&data.filter(x => x.category == 'Java')[0].title != '' ? html`<article>
                <h3>${data.filter(x => x.category == 'Java')[0].title}</h3>
                <p>${data.filter(x => x.category == 'Java')[0].content}</p>
                <a href=${`/details/${data.filter(x => x.category == 'Java')[0]._id}`} class="btn details-btn">Details</a>
            </article>`: html` <h3 class="no-articles">No articles yet</h3>`}
        </section>
        <section class="recent python">
            <h2>Python</h2>
            ${data.filter(x => x.category == 'Python').length > 0 &&  data.filter(x => x.category == 'Python')[0].title != '' ? html`
            <article>
                <h3>${data.filter(x => x.category == 'Python')[0].title}</h3>
                <p>${data.filter(x => x.category == 'Python')[0].content}</p>
                <a href=${`/details/${data.filter(x => x.category == 'Python')[0]._id}`} class="btn details-btn">Details</a>
            </article>`: html` <h3 class="no-articles">No articles yet</h3>`}
        </section>
    </section>


</section>`

const itemTemplate = (item) => html`
<section class="recent js">
    <h2>${data.category}</h2>
    <article>
        <h3>${data.title}}</h3>
        <p>${data.content}</p>
        <a href=${`/details/${item._id}`} class="btn details-btn">Details</a>
    </article>
</section>
`


export async function homePage(ctx) {
    console.log('Home page');
    const data = await getAllCategories();
    //console.log(data);
    ctx.render(allCategoriesTemplate(data));
}