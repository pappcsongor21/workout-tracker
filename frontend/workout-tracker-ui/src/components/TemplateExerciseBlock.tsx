import type { TemplateExerciseProps } from "../types/workoutTemplate"

const TemplateExerciseBlock = ({templateExercise}:TemplateExerciseProps) => {
  return (
    <div className="grid grid-cols-4 border-t min-h-12 items-center
    bg-white hover:bg-gray-300">
        <div>
            {templateExercise.exercise.name}
        </div>
        <div >
            {templateExercise.targetSets} X {templateExercise.targetRepsMin}-{templateExercise.targetRepsMax}
        </div>
        <div>
            {templateExercise.targetIntensity}
        </div>
        <div >
            {templateExercise.restSeconds}s rest
        </div>
    </div>
  )
}

export default TemplateExerciseBlock