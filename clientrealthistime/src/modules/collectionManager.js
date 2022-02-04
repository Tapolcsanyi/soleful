import { getToken } from "./authManager";

const baseUrl = "/api/collection";

export const getAllUserCollection = () => {

    return getToken().then(token => {
        return fetch(baseUrl, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                return res.json()
            } else {
                throw new Error("An error occurred while retrieving sneakers")
            }
        })
    })
}

export const addCollection = (sneaker) => {
    return getToken().then(token => {
        return fetch(baseUrl, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json"
            },
            body: JSON.stringify(sneaker)
        }).then(res => {
            if (res.ok) {
                return res.json()
            } else {
                throw new Error("An error occured when creating a tag")
            }
        })
    })
}

export const deleteCollection = (id) => {
    return getToken().then(token => {
        return fetch(`${baseUrl}/${id}`, {
            method: "DELETE",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
        })
    })
}