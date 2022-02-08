import { getToken } from "./authManager";

const baseUrl = "/api/user";

export const getAllUserProfiles = () => {

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
                throw new Error("An error occured while retrieving user profiles")
            }
        })
    })
}

export const getLoggedInUser = () => {

    return getToken().then(token => {
        return fetch(baseUrl + '/loggedUser', {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                return res.json()
            } else {
                throw new Error("An error occured while retrieving user profiles")
            }
        })
    })
}

export const getUserProfileById = (id) => {

    return getToken().then(token => {
        return fetch(baseUrl + `/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                return res.json()
            } else {
                throw new Error("An error occured while retrieving user profile details")
            }
        })
    })
}

export const getUserProfileByFirebaseId = (uid) => {

    return getToken().then(token => {
        return fetch(baseUrl + `/${uid}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                return res.json()
            } else {
                throw new Error("An error occured while retrieving user profile details")
            }
        })
    })
}