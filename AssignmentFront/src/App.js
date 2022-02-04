import Calculator from './Components/Calculator';
import { Grid } from '@mui/material';
import { useEffect, useState, useCallback } from 'react';
import CalculatorHistory from './Components/CalculatorHistory';
import { useCalculatorService, getResults } from './Services/CalculatorService';

function App() {
  const {error, call} = useCalculatorService();
  const [history, setHistory] = useState([]);

  const onResultsSubmitted = () =>
  {
    loadHistory();
  }

  const loadHistory = useCallback(async () =>
  {
    const [request, path] = getResults();
    const response = await call(request, path);
    if (response!=='error')
    {
      setHistory(response);
    }
  }, [call])

  useEffect(()=>{
    loadHistory();
  }, [loadHistory])

  return (
    <div className="App">
      <Grid container padding={2} spacing={2}>
        <Grid item>
          <Calculator onResultsSubmitted={onResultsSubmitted}/>
        </Grid>
        <Grid item>
          <CalculatorHistory
            history={history}
            error={error}
          />
        </Grid>
      </Grid>
    </div>
  );
}

export default App;
