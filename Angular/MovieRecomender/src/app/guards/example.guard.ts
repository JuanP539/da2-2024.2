import { CanActivateFn } from '@angular/router';

export const exampleGuard: CanActivateFn = (route, state) => {
  
  let canEnter = false;

  if(canEnter){
    canEnter = false;
  }
  else{
    canEnter = true;
  }

  return canEnter;
};
