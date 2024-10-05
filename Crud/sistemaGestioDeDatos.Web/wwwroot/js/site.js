// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    const datoInput = document.getElementById('datoInput');
    const gastoLabel = document.getElementById('gastoLabel');

    // Crear las variables
    let dato = '';
    let gasto = 0;

    // Función para actualizar el valor del label
    function actualizarGasto() {
        dato = datoInput.value;
    gasto = parseFloat(dato); // Convertir el valor a un número decimal
    gastoLabel.textContent = `Gasto: ${gasto}`;
        }

    // Asignar el evento 'input' al elemento de entrada
    datoInput.addEventListener('input', actualizarGasto);
