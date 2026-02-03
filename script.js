const form = document.getElementById('emi-form');
const emiOutput = document.getElementById('emi');
const interestOutput = document.getElementById('interest');
const totalOutput = document.getElementById('total');
const principalBar = document.getElementById('principal-bar');
const interestBar = document.getElementById('interest-bar');

const formatCurrency = (value) =>
  value.toLocaleString('en-IN', {
    style: 'currency',
    currency: 'INR',
    maximumFractionDigits: 0,
  });

const calculateEmi = (principal, annualRate, months) => {
  const monthlyRate = annualRate / 12 / 100;
  if (monthlyRate === 0) {
    return principal / months;
  }
  const rateFactor = Math.pow(1 + monthlyRate, months);
  return (principal * monthlyRate * rateFactor) / (rateFactor - 1);
};

const updateResults = () => {
  const principal = Number.parseFloat(form.principal.value);
  const rate = Number.parseFloat(form.rate.value);
  const tenureValue = Number.parseInt(form.tenure.value, 10);
  const tenureUnit = form['tenure-unit'].value;
  const months = tenureUnit === 'years' ? tenureValue * 12 : tenureValue;

  if (!Number.isFinite(principal) || !Number.isFinite(rate) || !Number.isFinite(months) || months <= 0) {
    emiOutput.textContent = '₹0';
    interestOutput.textContent = '₹0';
    totalOutput.textContent = '₹0';
    return;
  }

  const emi = calculateEmi(principal, rate, months);
  const totalPayment = emi * months;
  const totalInterest = totalPayment - principal;

  emiOutput.textContent = formatCurrency(emi);
  interestOutput.textContent = formatCurrency(totalInterest);
  totalOutput.textContent = formatCurrency(totalPayment);

  const principalShare = principal / totalPayment;
  const interestShare = totalInterest / totalPayment;

  principalBar.style.width = `${Math.max(principalShare * 100, 5)}%`;
  interestBar.style.width = `${Math.max(interestShare * 100, 5)}%`;
};

form.addEventListener('submit', (event) => {
  event.preventDefault();
  updateResults();
});

['input', 'change'].forEach((eventName) => {
  form.addEventListener(eventName, () => {
    updateResults();
  });
});

updateResults();
