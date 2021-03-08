function solve() {
    let createButton = document.querySelector('button.btn.create');
    createButton.addEventListener('click', createArticle);
 
    function createArticle(event) {
        event.preventDefault();
 
        let authorInput = document.querySelector('#creator');
        let titleInput = document.querySelector('#title');
        let categoryInput = document.querySelector('#category');
        let contentInput = document.querySelector('#content');
 
        let h1Title = document.createElement('h1');
        h1Title.textContent = titleInput.value;
 
        let categoryStrongElement = document.createElement('strong');
        categoryStrongElement.textContent = categoryInput.value;
        let categoryParagraph = document.createElement('p');
        categoryParagraph.textContent = 'Category: ';
        categoryParagraph.appendChild(categoryStrongElement);
 
        let creatorStrongElement = document.createElement('strong');
        creatorStrongElement.textContent = authorInput.value;
        let creatorParagraph = document.createElement('p');
        creatorParagraph.textContent = 'Creator: ';
        creatorParagraph.appendChild(creatorStrongElement);
 
        let contentParagraph = document.createElement('p');
        contentParagraph.textContent = contentInput.value;
 
        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('btn');
        deleteButton.classList.add('delete');
        deleteButton.addEventListener('click', deleteArticle);
 
        let archiveButton = document.createElement('button');
        archiveButton.textContent = 'Archive';
        archiveButton.classList.add('btn');
        archiveButton.classList.add('archive');
        archiveButton.addEventListener('click', archiveArticle);
        archiveButton.articleTitle = titleInput.value;
 
        let divButtons = document.createElement('div');
        divButtons.classList.add('buttons');
        divButtons.appendChild(deleteButton);
        divButtons.appendChild(archiveButton);
 
        let article = document.createElement('article');
        article.appendChild(h1Title);
        article.appendChild(categoryParagraph);
        article.appendChild(creatorParagraph);
        article.appendChild(contentParagraph);
        article.appendChild(divButtons);
 
        let mainSection = document.querySelector('main > section');
        mainSection.appendChild(article);
 
        authorInput.value = '';
        titleInput.value = '';
        categoryInput.value = '';
        contentInput.value = '';
    }
 
    function deleteArticle(event) {
        event.preventDefault();
 
        this.parentNode.parentNode.remove();
    }
 
    function archiveArticle(event) {
        event.preventDefault();
 
        this.parentNode.parentNode.remove();
 
        let archiveSectionOl = document.querySelector('section.archive-section ol');
 
        let li = document.createElement('li');
        li.textContent = event.target.articleTitle;
        archiveSectionOl.appendChild(li);
 
        let archivedArticlesListItems = archiveSectionOl.children;
        let archivedArticlesListItemsArray = Array.from(archivedArticlesListItems);
 
        archiveSectionOl.innerHTML = '';
 
        archivedArticlesListItemsArray.sort((a, b) => {
           return a.textContent.toLowerCase().localeCompare(b.textContent.toLowerCase());
        });
 
        for (const listItem of archivedArticlesListItemsArray) {
            archiveSectionOl.appendChild(listItem);
        }
    }
}