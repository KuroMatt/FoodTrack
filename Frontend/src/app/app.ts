import { Component, signal } from '@angular/core';
import { ShellComponent } from './core/layout/shell/shell';


@Component({
  selector: 'app-root',
  imports: [ShellComponent],
  templateUrl: './app.html',
  styleUrl: './app.css',
  standalone: true
})
export class App {
  protected readonly title = signal('FoodTrackUX');
}
