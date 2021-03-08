function solve() {
   const module = document.querySelector('.site-content main section');
   const author = document.getElementById('creator');
   const title = document.getElementById('title');
   const category = document.getElementById('category');
   const content = document.getElementById('content');
   const archive=document.querySelector('.archive-section ol');
   document.querySelector('.create').addEventListener('click', add);

   function add(ev) {
      ev.preventDefault();
      const article = document.createElement('article')

      const heading = document.createElement('h1')
      heading.textContent = title.value;

      const p1 = createElement('p',{},'Category: ')
      
      const pStrong = document.createElement('strong')
      pStrong.textContent=category.value;
      p1.appendChild(pStrong);

      const p2 = createElement('p',{},'Creator: ')
      
      const pStrong2 = document.createElement('strong')
      pStrong2.textContent=author.value;
      p2.appendChild(pStrong2);

      const p3 = document.createElement('p')
      p3.textContent = content.value;


      const divContainer=  createElement('div',{className: 'buttons'})

      const button1 =createElement('button',{className: 'btn delete'},'Delete')
      button1.addEventListener('click', function(e) {
         if (e.target.textContent == 'Delete') {
            let remove = e.target.parentNode.parentNode.remove();
        }
        
      })
      const button2 =createElement('button',{className: 'btn archive'},'Archive')

      button2.addEventListener('click', function(e) {
         if (e.target.textContent == 'Archive') {
            let move =e.target.parentNode.parentNode;
            let title=move.children[0].textContent;
            move.remove();
            let archiveUll=document.createElement('li');
            archiveUll.textContent=title;
            archive.appendChild(archiveUll);
            sortList();  
        }      
        
      })

      divContainer.appendChild(button1);
      divContainer.appendChild(button2);
      article.appendChild(heading);
      article.appendChild(p1);
      article.appendChild(p2);
      article.appendChild(p3);
      article.appendChild(divContainer);

      module.appendChild(article);
   }

   function sortList() {
      var list, i, switching, b, shouldSwitch; 5
      list = archive;
      switching = true;
      while (switching) {
          switching = false;
          b = list.getElementsByTagName("LI");
          for (i = 0; i < (b.length - 1); i++) {
              shouldSwitch = false;
              if (b[i].innerHTML.toLowerCase() > b[i + 1].innerHTML.toLowerCase()) {
                  shouldSwitch = true;
                  break;
              }
          }
          if (shouldSwitch) {
              b[i].parentNode.insertBefore(b[i + 1], b[i]);
              switching = true;
          }
      }
  }

   function createElement(tagName, attributes, ...content) {
      const element = document.createElement(tagName);

      //add attribute or event listener
      for (let attr in attributes) {
         if (attr.substring(0, 2) === 'on') {
            element.addEventListener(attr.substring(2).toLowerCase(), attributes[attr]);
         } else {
            element[attr] = attributes[attr];
         }
      }

      //add content or append a child element
      content.forEach(c => {
         if (typeof c === "string" || typeof c === 'number') {
            element.textContent = c;
         } else {
            element.appendChild(c)
         }
      });
      return element;
   }
}
