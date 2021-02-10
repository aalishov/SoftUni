function create(words) {
   const content = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');
      paragraph.style.display = 'none';
      paragraph.textContent = words[i];
      div.appendChild(paragraph);
      div.addEventListener('click',function(e){
         const p=e.target.children[0];
         const isVisible=p.style.display==='block';
         p.style.display=isVisible?'none':'block';
      })
      content.appendChild(div);
   }
}