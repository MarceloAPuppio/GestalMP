export const setHeaderAuth = () => {
  let token = sessionStorage.getItem("Token")
    ? sessionStorage.getItem("Token")
    : localStorage.getItem("Token");
  return `${token}`;
};
//TODO. Ac� puedo en el template string meterle un ? ${Math.Floor(Math.Random *500)}
export const loadTable = (table, data) => {
  table.innerHTML = "";
  for (const element of data) {
    table.innerHTML += `<tr>
      <td class="column column-1"><div class="table-img-wrapper"><img src="${element.url}" alt="" class="table-nombre-img"></div><span class="table-nombre-nombre">${element.nombre}</span></td>
      <td class="column column-2">${element.id}</td>
      <td class="column column-3">${element.mail}</td>
      <td class="column column-4">${element.domicilio}</td>
      <td class="column column-5">${element.estudios}</td>
    </tr>`;
  }
};

export const loadRoles = (select, options) => {
  select.innerHTML = "";
  for (const option of options) {
    let optionHTML = document.createElement("option");
    optionHTML.classList.add("aside__Login__Option");
    optionHTML.innerHTML = option.Nombre;
    optionHTML.value = option.Nombre;
    select.appendChild(optionHTML);
  }
};
