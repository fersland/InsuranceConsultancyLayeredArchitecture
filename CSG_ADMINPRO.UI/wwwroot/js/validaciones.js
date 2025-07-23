document.addEventListener('DOMContentLoaded', function () {
    // Solo números
    document.querySelectorAll('.only-numbers').forEach(input => {
        input.addEventListener('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    });

    // Solo letras y espacios
    document.querySelectorAll('.only-letters').forEach(input => {
        input.addEventListener('input', function () {
            this.value = this.value.replace(/[^a-zA-ZÁÉÍÓÚáéíóúÑñ\s]/g, '');
        });
    });

    // Otros validadores pueden añadirse aquí (por ejemplo, emails, fechas, etc.)
});