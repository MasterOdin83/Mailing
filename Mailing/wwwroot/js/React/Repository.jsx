export const getCurrentUsers = async (lastName = "", SortingOrderParameters = true) => {
    const result = await fetch(`https://localhost:44369/api/Mailing/GetMailingListWithParameters?LastNameParameters=${lastName}&SortingOrderParameters=${SortingOrderParameters}`);
    const data = await result.json();
    return data;
};

export const postNewUser = (lastName, firstName, emailAddress) => {
    let xhr = new XMLHttpRequest();
    xhr.open('POST', `https://localhost:44369/api/Mailing/PostNewAccount?lastName=${lastName}&firstName=${firstName}&emailAddress=${emailAddress}`);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send();
};
