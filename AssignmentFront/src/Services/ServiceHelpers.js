 //requestType="POST", "GET", "PUT" or "DELETE"
 export const request = (requestType, body) => {
    const request = 
    {
      method: requestType,
      headers: new Headers({
        Accept: "application/json",
        "Content-Type": "application/json",
      })
    };
    if (body)
    {
      request['body'] = body;
    }
  
    return request;
  }