import CssBaseline from '@mui/material/CssBaseline';
import { Container } from '@mui/system';
import { useCallback, useEffect, useState } from 'react';
import { Outlet } from 'react-router';
import { ToastContainer } from 'react-toastify';
import { useAppDispatch } from '../store/configureStore';
import { fetchCurrentUserAsnyc } from '../../features/account/accountSlice';
import { createTheme, ThemeOptions, ThemeProvider } from '@mui/material';
import 'react-toastify/dist/ReactToastify.css';

const themeOptions: ThemeOptions = {
    palette: {
      mode: 'light',
    },
  };

  const mainAppStyles = {
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  };

function App() {

    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(true);

    const initApp = useCallback(async () => {
        try {
            await dispatch(fetchCurrentUserAsnyc())
        }
        catch(error) {
            console.log(error);
        }
    }, [dispatch])

    useEffect(() => {
        initApp().then(() => setLoading(false))
    }, [initApp])

    const theme = createTheme(themeOptions);

    if (loading) return <span>Loading...</span>

    return (
        <ThemeProvider theme={theme}>
            <ToastContainer position='bottom-right' hideProgressBar theme='colored' />
            <CssBaseline />
            <Container sx={mainAppStyles}>
                <Outlet/>
            </Container>
        </ThemeProvider>
    );
}

export default App;
