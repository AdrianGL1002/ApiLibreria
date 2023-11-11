
const form = document.getElementById("buscarLibro");

form.addEventListener("submit", async (event) => {
    event.preventDefault();
    const bookData = eventToBooksData(event);
    const book = bookData.replace(/\s/g, '%20');
    console.log(bookData.replace(/\s/g, '%20'));
    const titulo = await fetch("http://localhost:5071/api/Book/OneBook?libro="+book);
    //                          http://localhost:5071/api/Book/OneBook?libro=El%20Gato%20Negro
    const consulta = await titulo.json();
    deleteRows();
    actualizarTablaTitulo(consulta);
});

function eventToBooksData(event){
    const elements = event.target.elements;
    const titulo = elements.libro.value;
    return titulo;
}

async function actualizarTablaTitulo(consulta){
    dibujarTabla(consulta);
}

async function actualizarTabla(){
    const libros= await obtenerLibrosApi();
    dibujarTabla(libros);
}

async function obtenerLibrosApi(){
    const respuesta = await fetch("http://localhost:5071/api/Book/AllBooks");
    const libros = await respuesta.json();
    return libros;

}

async function dibujarTabla(libros){
    libros.forEach(libro => {
        addBookToTable(libro)
    });

} 

function addBookToTable(libro){

    const dataBook = document.getElementById("tabla");
    const row = dataBook.insertRow(-1);
    const cell1 = row.insertCell(0);
    const cell2 = row.insertCell(1);
    const cell6 = row.insertCell(2);
    const cell3 = row.insertCell(3);
    const cell4 = row.insertCell(4);
    const cell5 = row.insertCell(5);
    
    cell1.innerHTML = libro.id;
    cell2.innerHTML = libro.title;
    cell3.innerHTML = libro.chapters;
    cell4.innerHTML = libro.pages;
    cell5.innerHTML = libro.price;
    cell6.innerHTML = libro.autor;
    /*
        {
        "id": 4,
        "title": "El señor de los anillos",
        "chapters": 8,
        "pages": 500,
        "price": 700,
        "authorId": 4,
        "author": null
    }
    */
}

function deleteRows() {
    const num = document.getElementById("tabla").rows.length;
    for(i = 1; i< num; i++){
        console.log(i);
        document.getElementById("tabla").deleteRow(1);
    }
}

document.addEventListener("DOMContentLoaded", () => {
    actualizarTabla();
});

