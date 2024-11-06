import { CanActivateFn } from '@angular/router';

export const exampleGuard: CanActivateFn = (route, state) => {
  
  let a = localStorage.getItem("facts");
  if(a != null){
    let b = JSON.parse(a);
    if(b.some((fact: string) => fact.includes("breed"))){
      return true;
    }
    else{
      return false;
    }
  }
  else{
    return false;
  }
};
