//#region global
//boot aOs
// AOS.init({
//     duration: 2000,
// });

//#region darkMode
// Manter a funcionalidade do menu de temas
document.addEventListener("DOMContentLoaded", function () {
    const themeButton = document.getElementById("btnMode");
    const themeMenu = document.getElementById("themeMenu");
    const loginMenu = document.getElementById("menu");

    // Carregar tema salvo no localStorage
    const savedTheme = localStorage.getItem("selectedTheme") || "NebulosaSolarLightMode";
    document.documentElement.className = savedTheme;

    // Destacar o tema salvo no menu
    highlightSelectedTheme(savedTheme);

    // Mostrar/esconder menu de temas
    themeButton.addEventListener("click", (event) => {
        event.stopPropagation(); // Impede o fechamento do menu de perfil
        themeMenu.classList.toggle("active");

        // Fechar o menu de login (perfil) se estiver aberto
        if (isMenuVisible) {
            loginMenu.classList.remove('active');
            isMenuVisible = false;
        }
    });

    // Alternar exibição de opções dentro das categorias
    window.toggleThemeOptions = function (category) {
        const optionsElement = document.getElementById(`${category}-options`);

        // Verifica se já está ativo
        const isActive = optionsElement.classList.contains("active");

        // Fecha todos os outros menus
        document.querySelectorAll(".theme-options").forEach(option => {
            option.classList.remove("active");
        });

        // Alterna somente o clicado
        if (!isActive) {
            optionsElement.classList.add("active");
        }
    };

    // Alterar o tema ao clicar nas opções
    window.changeTheme = function (theme) {
        // Aplicar o novo tema
        document.documentElement.className = theme;

        // Salvar o tema no localStorage
        localStorage.setItem("selectedTheme", theme);

        // Destacar a opção selecionada
        highlightSelectedTheme(theme);
    };

    // Função para destacar o tema selecionado
    function highlightSelectedTheme(selectedTheme) {
        // Remove a classe 'selected' de todas as opções
        document.querySelectorAll(".theme-option").forEach(option => {
            option.classList.remove("selected");
        });

        // Encontra a opção correspondente e adiciona a classe 'selected'
        document.querySelectorAll(".theme-option").forEach(option => {
            if (option.getAttribute("onclick")?.includes(selectedTheme)) {
                option.classList.add("selected");
            }
        });
    }
});


//#endregion


//#region Carrocel
let currentIndex = 1; // Começa com o índice 1 para destacar a segunda imagem
const items = document.querySelectorAll('.carousel__item');
const totalItems = items.length;

function updateCarousel() {
    items.forEach((item, index) => {
        item.classList.remove('active'); // Remove a classe active de todos os itens
        if (index === currentIndex) {
            item.classList.add('active'); // Adiciona a classe active ao item atual
        }
    });

    // Movendo o carrossel horizontalmente para mostrar as imagens
    const newTransform = -(currentIndex * 25); // Cada item ocupa 25% da largura
    document.querySelector('.carousel__wrapper').style.transform = `translateX(${newTransform}%)`;
}

// Função para alternar a seleção de imagens com os botões
function moveSlide(direction) {
    currentIndex = (currentIndex + direction + totalItems) % totalItems;  // Avança para o próximo item, e volta para o primeiro após o último
    updateCarousel();
}

document.addEventListener('DOMContentLoaded', () => {
    updateCarousel();
});
//#endregion


//#region Filtro

function toggleDropdown(menuId) {
    // Fechar todos os menus
    const allDropdowns = document.querySelectorAll('.dropdown-content');
    allDropdowns.forEach(dropdown => {
        if (dropdown.id !== menuId) {
            dropdown.classList.remove('active');
        }
    });

    // Alternar a exibição do menu clicado
    const selectedMenu = document.getElementById(menuId);
    if (selectedMenu) {
        selectedMenu.classList.toggle('active');
    }
}

function sortGames(order) {
    const gamesContainer = document.querySelector('.game-section__Filters');
    const games = Array.from(gamesContainer.children);

    // Ordena os jogos pelo preço
    games.sort((a, b) => {
        const priceA = parseInt(a.getAttribute('data-price'));
        const priceB = parseInt(b.getAttribute('data-price'));

        return order === 'asc' ? priceA - priceB : priceB - priceA;
    });

    // Reorganiza os jogos no DOM
    games.forEach(game => gamesContainer.appendChild(game));
}

function filterGames(category) {
    const cards = document.querySelectorAll('.game-cardFilter');
    const buttons = document.querySelectorAll('.game-section__filters button');

    // Atualizar o estado ativo dos botões
    buttons.forEach(button => button.classList.remove('active'));
    document.querySelector(`button[data-category="${category}"]`).classList.add('active');

    // Filtrar os jogos
    cards.forEach(card => {
        const categories = card.getAttribute('data-category');
        if (category === 'all' || categories.includes(category)) {
            card.style.display = 'block'; // Exibir o jogo
        } else {
            card.style.display = 'none'; // Esconder o jogo
        }
    });
}

// Inicializa o filtro para exibir todos os jogos por padrão
window.onload = function () {
    filterGames('all');
};

function toggleFilterBox(filterId) {
    const filterBox = document.getElementById(filterId);
    if (filterBox.style.display === 'none' || filterBox.style.display === '') {
        filterBox.style.display = 'block';
    } else {
        filterBox.style.display = 'none';
    }
}

function sortGames(order) {
    const gamesContainer = document.querySelector('.game-section__Filters');
    const games = Array.from(gamesContainer.children);

    // Ordena os jogos pelo preço
    games.sort((a, b) => {
        const priceA = parseInt(a.getAttribute('data-price'));
        const priceB = parseInt(b.getAttribute('data-price'));

        return order === 'asc' ? priceA - priceB : priceB - priceA;
    });

    // Reorganiza os jogos no DOM
    games.forEach(game => gamesContainer.appendChild(game));
}

function filterGames(category) {
    const cards = document.querySelectorAll('.game-cardFilter');
    const buttons = document.querySelectorAll('.filters-left button'); // Alterado para escopo correto dos botões

    // Atualizar o estado ativo dos botões
    buttons.forEach(button => button.classList.remove('active')); // Remove a classe 'active' de todos os botões
    const selectedButton = document.querySelector(`.filters-left button[data-category="${category}"]`);
    if (selectedButton) {
        selectedButton.classList.add('active'); // Adiciona 'active' ao botão selecionado
    }

    // Filtrar os jogos
    cards.forEach(card => {
        const categories = card.getAttribute('data-category');
        if (category === 'all' || categories.includes(category)) {
            card.style.display = 'block'; // Exibir o jogo
        } else {
            card.style.display = 'none'; // Esconder o jogo
        }
    });
}



// Inicializa o filtro para exibir todos os jogos por padrão
window.onload = function () {
    filterGames('all');
};



//#endregion

//MenuHamburguer Celular
document.getElementById("hamburgerMenu").addEventListener("click", function () {
    const menu = document.getElementById("mainMenu");
    menu.classList.toggle("active");
});

//#endregion



document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("perfilBtn").addEventListener("click", function () {
        var menu = document.getElementById("menu");
        menu.classList.toggle("active");
    });
});


