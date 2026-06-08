import * as React from "react";

/**
 * Card surface — white panel with soft shadow and 12px radius.
 * Compose with CardHeader / CardBody / CardFooter.
 * @startingPoint section="Components" subtitle="Card with header, body & footer" viewport="700x300"
 */
export interface CardProps extends React.HTMLAttributes<HTMLDivElement> {
  /** Remove the drop shadow */
  flush?: boolean;
}
export function Card(props: CardProps): JSX.Element;

export interface CardHeaderProps extends React.HTMLAttributes<HTMLDivElement> {
  title?: React.ReactNode;
  subtitle?: React.ReactNode;
  /** Right-aligned actions */
  toolbar?: React.ReactNode;
}
export function CardHeader(props: CardHeaderProps): JSX.Element;
export function CardBody(props: React.HTMLAttributes<HTMLDivElement>): JSX.Element;
export function CardFooter(props: React.HTMLAttributes<HTMLDivElement>): JSX.Element;
