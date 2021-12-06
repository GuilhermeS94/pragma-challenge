import React, { useEffect, useState } from "react";

export interface CustomRequest {
    Headers?: {};
    Method: string; // "GET" or "PUT" or "POST" or "PATCH"
    EndPoint: string;
    Body?: object;
}

export interface CustomResponse {
    Data: any;
}

export enum HttpStatusCode {
    OK = 200,
    CREATED = 201,
    OK_NO_CONTENT = 204,
    NOT_AUTHORIZED = 401,
    NOT_AUTHENTICATED = 403,
    GENERAL_ERROR = 500
}

function useCallApi(inputRequest: CustomRequest): [CustomResponse, boolean, React.Dispatch<React.SetStateAction<CustomRequest>>] {

    const [isLoading, setIsLoading] = useState(false);
    const [requestInfos, setRequestInfos] = useState(inputRequest);
    const [responseInfos, setResponseInfos] = useState({} as CustomResponse);
  
    useEffect(() => {
        if (Object.keys(requestInfos).length === 0 && requestInfos.constructor === Object)
            return;
  
        const promise = new Promise((resolve: any, reject: any) => {
            const url = requestInfos.EndPoint;
            const configs = {
                body: requestInfos.Body ? JSON.stringify(requestInfos.Body) : "",
                headers: requestInfos.Headers ? requestInfos.Headers : {},
                method: requestInfos.Method
            };
  
            fetch(url, configs).then((response: Response) => {
                switch (response.status) {
                    case HttpStatusCode.OK:
                    case HttpStatusCode.CREATED:
                    case HttpStatusCode.OK_NO_CONTENT:
                        response.clone().json().then((data: any) => {
                            resolve(data);
                        })
                        .catch(() => {
                            resolve(null);
                        });
                    break;
                    case HttpStatusCode.NOT_AUTHENTICATED:
                        response.clone().json().then((data: any) => {
                            reject(data);
                        })
                        .catch((error: Error) => {
                            reject(error);
                        });
                    break;
                    case HttpStatusCode.NOT_AUTHORIZED:
                        response.clone().json().then((data: any) => {
                            reject(data);
                        })
                        .catch((error: Error) => {
                            reject(error);
                        });
                    break;
                    case HttpStatusCode.GENERAL_ERROR:
                        response.clone().json().then((data: any) => {
                            reject(data);
                        })
                        .catch((error: Error) => {
                            reject(error);
                        });
                    break;
                    default:
                    response.clone().json().then((data: any) => {
                        reject(data);
                    })
                    .catch(() => {
                        reject(null);
                    });
                }
            })
            .catch((error: Error) => {
                reject(error);
            });
        });
  
        setIsLoading(true);
  
        promise.then(
        (httpResponse: any) => {
            setResponseInfos({ Data: httpResponse });
            setIsLoading(false);
        },
        (error: Error) => {
            setResponseInfos({ Data: error });
            setIsLoading(false);
        });
    }, [requestInfos]);
  
    return [responseInfos, isLoading, setRequestInfos];
}

export default useCallApi;