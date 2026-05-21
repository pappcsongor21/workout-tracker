import { Link } from "react-router-dom"

const CreateWorkoutTemplateCard = () => {
  return (
    <div className="flex w-full justify-center py-4">
      <Link
        to={'/templates/create'}
        className="max-w-xl w-full cursor-pointer rounded-xl bg-slate-400 py-5
         text-center text-4xl font-bold tracking-wide text-white shadow-lg 
         transition duration-150 ease-in-out hover:scale-105 hover:bg-slate-500 
         active:scale-100 block"
      >
        Create new template
      </Link>
    </div>
  )
}
export default CreateWorkoutTemplateCard