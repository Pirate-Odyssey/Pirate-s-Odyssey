export interface AlertData {
  type: 'info' | 'warning' | 'error' | 'success';
  content: string;
  hasAction: boolean;
}
