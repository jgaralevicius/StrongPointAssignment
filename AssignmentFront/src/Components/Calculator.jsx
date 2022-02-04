import {useState} from 'react'
import {Paper, Stack, TextField, InputAdornment, Button, Typography} from '@mui/material'
import {useCalculatorService, calculateResult} from '../Services/CalculatorService'


export default function Calculator({onResultsSubmitted}) {
    const [formValues, setFormValues] = useState({mass:"", velocity:""});
    const {call, error, loading} = useCalculatorService();
    const [result, setResult] = useState({energy: "", comment: ""})
    const [errors, setErrors] = useState({mass:"", velocity:""})

    const onValueChange = ({target}) => {
        // match positive decimal
        if (target.value.match(/^$|^((\d+(\.\d*)?)|(\.\d+))$/) )
        {
            setFormValues(previous=>{
                return ({...previous, [target.id]:target.value})
            })
        }
    }

    const onSubmit = async () => {
        let newErrors = {};
        let canPost = true;

        for (let property in errors) {
            newErrors[property] = formValues[property] ? "" : "Value required";
            if (newErrors[property]) {
                canPost = false;
            }
        }
        setErrors(newErrors);

        if (!canPost) {
            return;
        }

        const [request, path] = calculateResult(formValues);
        const response = await call(request, path);
        
        if (response!=='error') {
            setResult(response);
            onResultsSubmitted();
        }
        
    }

    return (
    <Paper>
        <Stack padding={2} spacing={2}>
            <Typography alignSelf="center">Calculator</Typography>
            <Typography>Calculate Kinetic energy:</Typography>
            <TextField
                id="mass"
                label = "Mass"
                InputProps={{
                    endAdornment: <InputAdornment position="end">kg</InputAdornment>,
                }}
                value={formValues.mass}
                onChange={onValueChange}
                error={errors['mass']!==""}
                helperText={errors['mass']}
            />
            <TextField
                id="velocity"
                label = "Velocity"
                InputProps={{
                    endAdornment: <InputAdornment position="end">m/s</InputAdornment>,
                }}
                value={formValues.velocity}
                onChange={onValueChange}
                error={errors['velocity']!==""}
                helperText={errors['velocity']}
            />
            
            <Button 
                variant="contained"
                onClick={onSubmit}
                disabled={loading}
                >
                Calculate
            </Button>
            {error && <Typography color='red'>{error}</Typography>}
            <ResultSection result={result}/>
        </Stack>
    </Paper>
    )
}

function ResultSection({result}) {
    if (!result.energy) {
        return (<></>)
    }

    return (
    <>
        <Typography>
            {`Result: ${result.energy} J`}
        </Typography>
        <Typography>
            {`${result.comment}`}
        </Typography>
    </>
    )
}

