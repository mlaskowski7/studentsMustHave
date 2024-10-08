export interface Student {
  id: number;
  username: string;
  homeworks: Homework[];
  projects: Project[];
  skills: Skill[];
}

export interface Homework {
  id: number;
  title: string;
  deadline: Date;
  description: string;
  student: Student;
  subject: Subject;
}

export interface Project {
  id: number;
  title: string;
  description: string;
  deadline: Date;
  student: Student;
  techs: Tech[];
}

export interface Skill {
  id: number;
  level: Level;
  tech: Tech;
  student: Student;
}

export interface Tech {
  id: number;
  name: string;
  skills: Skill[];
  projects: Project[];
}

export interface Subject {
  id: number;
  name: string;
  importance: Range<1, 10>;
  homeworks: Homework[];
}

type Enumerate<
  N extends number,
  Acc extends number[] = []
> = Acc["length"] extends N
  ? Acc[number]
  : Enumerate<N, [...Acc, Acc["length"]]>;

type Range<F extends number, T extends number> = Exclude<
  Enumerate<T>,
  Enumerate<F>
>;

export enum Level {
  FUNDAMENTALS,
  ADVANCED,
  EXPERIENCED,
}
