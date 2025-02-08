async function fetchLongShortUrls() {
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get('id');

    if (id) {
        const response = await fetch(`http://localhost:8080/shortener/urls/${id}`, {method: "GET"})

        const json = await response.json();

        const urlTableHead = document.getElementById('urlTableHead');
        urlTableHead.innerHTML = `
            <tr>
                <th>Длинный URL</th>
                <th>Сокращенный URL</th>
            </tr>
            `;
        const urlTableBody = document.getElementById('urlTableBody');
        const urlTableRow = document.createElement('tr');
        urlTableRow.innerHTML = `
            <td><a href="${json.longUrl}">${json.longUrl}</a></td>
            <td><a href="http://localhost:8080/${json.shortUrl}">http://localhost:8080/${json.shortUrl}</a></td>
            `;
        urlTableBody.appendChild(urlTableRow);
    }
}

async function createUrl() {
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get('id');

    const method = id ? 'PUT' : 'POST';
    const url = id ? `http://localhost:8080/shortener/urls/${id}` : 'http://localhost:8080/shortener';
    const longUrl = document.getElementById('longUrl').value;

    const response = await fetch(url, {
        method: method,
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({longUrl})
    });

    if (response.ok) {
        window.location.href = 'index.html';
    } else {
        alert('Некорректная форма URL. Корректные форматы: http://example.com/ или https://foo.net/bar?baz=1');
    }
}

document.addEventListener('DOMContentLoaded', fetchLongShortUrls);