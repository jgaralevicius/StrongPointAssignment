import { useState, useCallback } from 'react';
import { request } from "./ServiceHelpers"
const baseUrl = process.env.REACT_APP_CALCULATOR_BASE_URL;

export function useCalculatorService()
{
    const [error, setError] = useState('');
    const [loading, setloading] = useState(false);

    const call = useCallback(async (request, path) => {
        setloading(true);
        const response = await callAPI(request, path);
        setloading(false);
        if (response.error)
        {
            setError(response.error);
            return 'error';
        }
        else 
        {
            setError('');
            return response;
        }
    }, [])

    return {call, setError, loading, error};
}

async function callAPI(request, path)
{
    try {
        if(request.body) {
            request.body = JSON.stringify(request.body);
        }
        const response = await fetch(baseUrl+path, request);

        if (response.status!==200) {
            let errorObject = await response.json();
            let error = "Unknown error";

            if (errorObject.error)
            {
                error = errorObject.error;
            }
            else if (response.status===400)
            {
                error = "Incorrect request";
            }
            else if (response.status===500)
            {
                error = "Server error";
            }
            
            return {error}
        }

        return await response.json();
    }
    catch (e)
    {
        return {error : e.message};
    }
}

// use these functions to get request definition to use in 'call' function above
export const calculateResult = (form) => {
    return [request('POST', form), '/calculations'];
}
export const getResults = () => {
    return [request('GET', ''), `/calculations`];
}