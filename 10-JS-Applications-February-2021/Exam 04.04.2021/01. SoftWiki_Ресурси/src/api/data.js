import * as api from './api.js';

const host = 'http://localhost:3030';

api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllArticles() {
    return await api.get(host +'/data/wiki?sortBy=_createdOn%20desc');
}

export async function getAllCategories() {
    return await api.get(host +'/data/wiki?sortBy=_createdOn%20desc&distinct=category');
}

export async function addItem(item) {
    return await api.post(host + '/data/wiki', item);
}

export async function getItem(id) {
    return await api.get(host + '/data/wiki/' + id);
}

export async function editItem(id, item) {
    return await api.put(host + '/data/wiki/' + id, item);
}

export async function deleteItem(id) {
    return await api.del(host + '/data/wiki/' + id);
}