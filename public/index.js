document.addEventListener('DOMContentLoaded', () => {
  const container = document.getElementById('books-container');

  fetch('/api/books')
    .then(res => {
      if (!res.ok) {
        throw new Error('API respondeu com erro');
      }
      return res.json();
    })
    .then(books => {
      books.forEach(book => {
        const bookHTML = `
          <div class="col-md-3 col-sm-6 hero-feature text-center">
            <div class="thumbnail">
              <img src="img/${book.cover}" alt="${book.name}">
              <div class="caption">
                <h3>${book.name}</h3>
                <p>${book.description}</p>
                <p>${book.price}</p>
                <p>
                  <a href="#" class="btn btn-primary">Comprar!</a>
                  <a href="#" class="btn btn-default">Detalhes</a>
                </p>
              </div>
            </div>
          </div>
        `;
        container.innerHTML += bookHTML;
      });
    })
    .catch(err => {
      console.error('Erro ao carregar os livros:', err);
      container.innerHTML = '<p>Erro ao carregar os livros.</p>';
    });
});