import { useAppSelector } from "../../app/store/configureStore";
import AdminHomePage from "./AdminHomePage";
import UserHomePage from "./UserHomePage";
function HomePage() {
    const { user } = useAppSelector(state => state.account);
    return (
        <>
            {user?.userRoles.includes('admin') && <AdminHomePage />}
            {user?.userRoles.includes('user') && <UserHomePage />}
        </>
    )
}

export default HomePage;