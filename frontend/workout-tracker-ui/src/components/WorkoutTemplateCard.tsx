import type { WorkoutTemplateCardProps } from "../types/workoutTemplate"
import TemplateExerciseBlock from "./TemplateExerciseBlock"

const WorkoutTemplateCard = ({workoutTemplate}:WorkoutTemplateCardProps) => {
  return (
    <section className="py-4">
        <div className="w-full max-w-125 bg-white rounded-xl overflow-hidden shadow-lg">
        
        <div className={`bg-purple-300 text-center text-3xl font-bold py-3 tracking-wide`}>
            {workoutTemplate.name}
        </div>
        
        <div className="flex flex-col w-full text-center">
            {workoutTemplate.exercises.map((exercise)=>(
                <TemplateExerciseBlock key={exercise.id} templateExercise={exercise} />
            ))}
        </div>
    </div>
    </section>
  )
}

export default WorkoutTemplateCard