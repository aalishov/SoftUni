import { html } from '../../node_modules/lit-html/lit-html.js'
import { register } from '../api/data.js';


const registerTemplate = (onSubmit) => html`
        <section id="register-page" class="content auth">
            <h1>Register</h1>
        
            <form id="register" action="#" method="" @submit=${onSubmit}>
                <fieldset>
                    <blockquote>Knowledge is not simply another commodity. On the contrary. Knowledge is never used up.
                        It
                        increases by diffusion and grows by dispersion.</blockquote>
                    <p class="field email">
                        <label for="register-email">Email:</label>
                        <input type="email" id="register-email" name="email" placeholder="maria@email.com">
                    </p>
                    <p class="field password">
                        <label for="register-pass">Password:</label>
                        <input type="password" name="password" id="register-pass">
                    </p>
                    <p class="field password">
                        <label for="register-rep-pass">Repeat password:</label>
                        <input type="password" name="rep-pass" id="register-rep-pass">
                    </p>
                    <p class="field submit">
                        <input class="btn submit" type="submit" value="Register">
                    </p>
                    <p class="field">
                        <span>If you already have profile click <a href="#">here</a></span>
                    </p>
                </fieldset>
            </form>
        </section>`



export async function registerPage(ctx) {
    //console.log('Register  page');
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const email = formData.get('email').trim();
        const password = formData.get('password').trim();
        const repass = formData.get('rep-pass').trim();
       
        if (!email || !password || !repass ) {
            //return showNotification('All fields are required!');
            return alert('All fields are required!');
        }
        if(password != repass){
           // return showNotification('All fields are required!');
            return alert('Passwords should match!');
        }

        await register(email, password);
        ctx.setUserNav();
        ctx.page.redirect('/');
    }
}