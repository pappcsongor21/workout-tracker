export interface TemplateExercise{
    id: number;
    exercise:{
        id: number;
        name: string;
        muscleGroup: string;
        description: string;
    }
    orderNum: number;
    targetSets: number;
    targetRepsMin: number;
    targetRepsMax: number;
    targetIntensity: string;
    restSeconds: number;
}

export interface WorkoutTemplate{
    id: number;
    name: string;
    colorHex: string;
    exercises: TemplateExercise[];
}

export interface WorkoutTemplateCardProps {
    workoutTemplate: WorkoutTemplate;
}

export interface TemplateExerciseProps {
    templateExercise: TemplateExercise;
}