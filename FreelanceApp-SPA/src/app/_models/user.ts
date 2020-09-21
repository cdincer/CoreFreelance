import { Photo } from './photo';

export interface User {
    id: number;
    username: string;
    experience: number;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    country: string;
    personalsummary?: string;
    lookingFor?: string;
    photos?: Photo[];
}