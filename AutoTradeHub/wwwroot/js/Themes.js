const darkModeSwitchInput = document.querySelector('input#darkModeSwitch');
const bodyTag = document.querySelector('[data-tag="html"]');

const themeSwitch = () => {
    var currentState = getCookie("colorTheme");
    if (currentState == "") {
        currentState = "light"
    }

    switch (currentState) {
        case "light":
            bodyTag.setAttribute('data-bs-theme', "dark");
            document.cookie = "colorTheme = dark; path=/; max-age=3600";
            break;
        default:
            bodyTag.setAttribute('data-bs-theme', "light");
            document.cookie = "colorTheme = light; path=/; max-age=3600";
    }
};


function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
