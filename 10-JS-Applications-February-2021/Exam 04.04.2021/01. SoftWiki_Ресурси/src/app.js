import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import {logout } from './api/data.js';

import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { allArticlesPage } from './views/allArticles.js';
import { homePage } from './views/home.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';

page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/all', decorateContext, allArticlesPage);
page('/create', decorateContext, createPage);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);

const main = document.getElementById('main-content');

setUserNav();

document.getElementById('logoutBtn').addEventListener('click',logout);

// Start application
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}

function setUserNav() {
    const userId = sessionStorage.getItem('userId');
    if (userId != null) {
        //console.log('user');
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    }
    else {
        //console.log('guest');
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}

document.getElementById('logoutBtn').addEventListener('click',async()=>{
    await logout();
    setUserNav();
    page.redirect('/');
});