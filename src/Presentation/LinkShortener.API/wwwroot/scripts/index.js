async function fetchUrls() {
    const response = await fetch('http://localhost:8080/shortener/urls', { method: "GET" });

    const json = await response.json();

    const urlTableBody = document.getElementById('urlTableBody');
    urlTableBody.innerHTML = '';

    json.forEach(item => {
        const urlTableRow = document.createElement('tr');
        urlTableRow.setAttribute("row-id", item.id);
        urlTableRow.innerHTML = `
        <td>${item.longUrl}</td>
        <td><a href="http://localhost:8080/shortener/${item.shortUrl}">http://localhost:8080/shortener/${item.shortUrl}</a></td>
        <td>${new Date(item.createdAt).toLocaleString()}</td>
        <td>${item.clickCount}</td>
        <td class="button-container">
            <button class="button delete" onclick="deleteUrl('${item.id}')">Удалить</button>
            <button class="button edit" onclick="editUrl('${item.id}')">Изменить</button>
        </td>
        `;
        urlTableBody.appendChild(urlTableRow);
    });
}

function editUrl(id) {
    window.location.href = `edit.html?id=${id}`;
}

async function deleteUrl(id) {
    const response = await fetch(`http://localhost:8080/shortener/urls/${id}`, { method: "DELETE" });

    if (response.ok) {
        document.querySelector(`tr[row-id="${id}"]`).remove();
    } else {
        const json = response.json();
        alert(json.message);
    }
}

document.addEventListener('DOMContentLoaded', fetchUrls);