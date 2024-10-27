import { Routes } from '@angular/router';
import { MovieItem } from './components/movie-item.component';
import { DogfactComponent } from './components/dogfact/dogfact.component';
import { exampleGuard } from './guards/example.guard';

export const routes: Routes = [
    { path: 'movie', component: MovieItem, canActivate: [exampleGuard]},
    { path: 'randomFact', component: DogfactComponent }
];
