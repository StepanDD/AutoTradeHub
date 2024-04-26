const darkModeSwitchInput = document.querySelector('input#darkModeSwitch');
const bodyTag = document.querySelector('[data-tag="html"]');

window.onload = function () {
    if (localStorage.getItem('theme') == 'dark') {
        bodyTag.setAttribute('data-bs-theme', "dark");
    }
}

const themeSwitch = () => {
    const currentState = bodyTag.getAttribute('data-bs-theme');

    switch (currentState) {
        case "light":
            bodyTag.setAttribute('data-bs-theme', "dark");
            localStorage.setItem("theme", "dark");
            break;
        default:
            bodyTag.setAttribute('data-bs-theme', "light");
            localStorage.setItem("theme", "light");
    }
};

/*darkModeSwitchInput.addEventListener('onclick', themeSwitch);*/