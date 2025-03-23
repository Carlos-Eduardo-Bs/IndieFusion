// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById('logo-button').addEventListener('click', function () {
    const menu = document.getElementById('topbar-menu-custom');
    menu.classList.toggle('hidden');
    menu.classList.toggle('visible');
});



