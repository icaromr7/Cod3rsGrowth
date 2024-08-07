sap.ui.define([
], function () {
	"use strict";
    const request = 
    {
        _request : async function(url, method = 'GET', data = null){
            const options = {
                method,
                headers: {
                    'Content-Type': 'application/json'
                }
            }
            if(data){
                options.body = JSON.stringify(data);
            }
            return  fetch(url, options)               
                .then(response => {
                    if (!response.ok) {
                    console.log(response);
                        return Promise.reject(response);
                    };
                    return response;
                })
                .then(response=> {
                    return response.json().catch(() => response.headers.get('Content-Type'));
                })
        },
    }
    return request;
});