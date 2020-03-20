//import things
import Sidebar from "./components/Sidebar";
import Header from "./components/Header";
import Footer from "./components/Footer";
import Artists from "./components/Artists";
import apiActions from "./api/apiActions";


export default pageBuild;

function pageBuild() {
    sidebar();
    footer();
    header();
    navArtists();
}

function header() {
    const header = document.querySelector("#header");
    header.innerHTML = Header();
}

function sidebar() {
    const sidebar = document.querySelector(".sidebar-div");
    sidebar.innerHTML = Sidebar();
}

function footer() {
    const footer = document.querySelector("#footer");
    footer.innerHTML = Footer();
}

function navArtists() {
    const artistsNavButton = document.querySelector(".nav_artists");
    const mainDiv = document.querySelector(".main-div");

    artistsNavButton.addEventListener("click", function () {
        apiActions.getRequest("https://localhost:44313/api/Artist",
            artists => {
                console.log(artists);
                mainDiv.innerHTML = Artists(artists);
            }
        )
    });

    mainDiv.addEventListener("click", function () {
        if (event.target.classList.contains("add-artist__submit")) {
            const artistName = event.target.parentElement.querySelector(".add-artist__artist-name").value;
            const artistGenre = event.target.parentElement.querySelector(".add-artist__artist-genre").value;
            console.log(artistName);

            var requestBody = {
                Name: artistName,
                Genre: artistGenre
            }

            apiActions.postRequest(
                "https://localhost:44313/api/Artist",
                requestBody,
                artists => {
                    console.log(artists);
                    mainDiv.innerHTML = Artists(artists);
                }
            )
        }
    })
}